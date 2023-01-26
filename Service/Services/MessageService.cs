using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

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
            List<User> users = new List<User>();
            List<Message> messages = _messageRepository.GetAll().Where(x => x.SecondUserId == id || x.FirstUserId == id).ToList();

            foreach (var message in messages)
            {
                message.SecondUser = _userRepository.GetAll().Include(x=>x.Photos).Where(x => x.Id == message.SecondUserId).FirstOrDefault();
                message.FirstUser = _userRepository.GetAll().Include(x=>x.Photos).Where(x => x.Id == message.FirstUserId).FirstOrDefault();

                if (!(users.Contains(message.SecondUser)))
                {
                    users.Add(message.SecondUser);
                }
                else if (!(users.Contains(message.FirstUser)))
                {
                    users.Add(message.FirstUser);
                }
            }
            return users;
        }

        public List<Message> GetConversation(int firstUserId, int secondUserId)
        {
            List<Message> messages = _messageRepository.GetAll().Where(x => x.FirstUserId == firstUserId && x.SecondUserId == secondUserId || (x.FirstUserId == secondUserId && x.SecondUserId == firstUserId)).ToList();

            foreach (var message in messages)
            {
                message.FirstUser = _userRepository.GetAll().Include(x => x.Photos).Include(x=>x.Account).Where(x => x.Id == message.FirstUserId).FirstOrDefault();
                message.SecondUser = _userRepository.GetAll().Include(x => x.Photos).Include(x=>x.Account).Where(x => x.Id == message.SecondUserId).FirstOrDefault();
            }
            return messages;
        }

    }
}