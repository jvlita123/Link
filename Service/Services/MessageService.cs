using Data.Entities;
using Data.Repositories;

namespace Service.Services
{
    public class MessageService
    {
        private readonly MessageRepository _messageRepository;
        private readonly UserRepository _userRepository;

        public MessageService(MessageRepository messageRepository, UserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        public List<Message> GetAll()
        {
            List<Message> messages = _messageRepository.GetAll().ToList();

            return messages;
        }

        public Message Add(Message message)
        {
            Message? newMessage = _messageRepository.AddAndSaveChanges(message);

            return newMessage;
        }

        public void Update(Message message)
        {
            _messageRepository.UpdateAndSaveChanges(message);
        }

        public Message? SendMessage(int firstUserId, int secondUserId, string text)
        {
            User firstUser = _userRepository.GetById(firstUserId);
            User secondUser = _userRepository.GetById(secondUserId);

            if (firstUser != null && secondUser != null)
            {
                var message = new Message()
                {
                    FirstUserId = firstUserId,
                    SecondUserId = secondUserId,
                    FirstUser = firstUser,
                    SecondUser = secondUser,
                    Text = text,
                    ReactionId = 1,
                };
                _messageRepository.AddAndSaveChanges(message);
                secondUser.Messages.Add(message);
                _userRepository.UpdateAndSaveChanges(secondUser);

                return message;
            }
            else
            {
                return null;
            }
        }
        
        public List<Message> GetUserMessages(int id)
        {
            List<Message> messages = _messageRepository.GetAll().Where(x => x.SecondUserId == id).ToList();
            return messages;
        }

        public List<Message> GetSentMessages(int id)
        {
            List<Message> messages = _messageRepository.GetAll().Where(x => x.FirstUserId == id).ToList();
            return messages;
        }

        public List<User> GetUserConversations(int id)
        {
          //  List<Message> messages = _messageRepository.GetAll().Where(x => x.FirstUserId == id || x.SecondUserId == id).ToList();
            List<User> users = new List<User>();


            List<Message> sentMessages = _messageRepository.GetAll().Where(x => x.FirstUserId == id).ToList();//SENT MESSAGES
            List<Message> receivedMessages = _messageRepository.GetAll().Where(x => x.SecondUserId == id).ToList();//RECEIVED

            if (sentMessages.Count>0)
            {
                foreach(var message in sentMessages)
                {
                    message.SecondUser = _userRepository.GetById(message.SecondUserId);

                    if (!(users.Contains(message.SecondUser)))
                    {
                        users.Add(message.SecondUser);
                    }
                }
            }

            if (receivedMessages.Count > 0)
            {
                foreach (var message in receivedMessages)
                {
                    message.SecondUser = _userRepository.GetById(message.SecondUserId);

                    if (!(users.Contains(message.SecondUser)))
                    {
                        users.Add(message.SecondUser);
                    }
                }
            }

            return users;
        }

        public List<Message> GetConversation(int firstUserId, int secondUserId)
        {
            List<Message> messages = _messageRepository.GetAll().Where(x => x.FirstUserId == firstUserId && x.SecondUserId == secondUserId ||( x.FirstUserId == secondUserId && x.SecondUserId == firstUserId)).ToList();

           
            foreach (var message in messages)
            {
                message.FirstUser = _userRepository.GetById(message.FirstUserId);
                message.SecondUser = _userRepository.GetById(message.SecondUserId);
            }
            return messages;
        }

    }
}