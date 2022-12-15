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
    }
}