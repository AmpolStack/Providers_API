using Providers_API.BLL.Definitions;
using Providers_API.DAL.Definitions;
using Providers_API.Models;

namespace Providers_API.BLL.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IGenericRepository<Contact> _repository;

        public ContactService(IGenericRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<Contact> addNewContact(Contact contact)
        {
            return await _repository.Create(contact);
        }

        public async Task<bool> removeContact(Contact contact)
        {
            return await _repository.Delete(contact);
        }

        public async Task<bool> updateContact(Contact contact)
        {
            return await _repository.Update(contact);
        }
        public async Task<IQueryable<Contact>> getAllContactsByProvider(int idProvider)
        {
            return await _repository.GetAll(x => x.ProviderId == idProvider);
        }

        public async Task<IQueryable<Contact>> GetAllForProviderId(int providerId)
        {
            return await _repository.GetAll(x => x.ProviderId == providerId);
        }

    }
}
