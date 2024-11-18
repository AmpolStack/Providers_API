using Providers_API.Models;

namespace Providers_API.BLL.Definitions
{
    public interface IContactService
    {
        Task<Contact> addNewContact(Contact contact);
        Task<bool> updateContact(Contact contact);
        Task<bool> removeContact(Contact contact);

        Task<IQueryable<Contact>> GetAllForProviderId(int providerId);
    }
}
