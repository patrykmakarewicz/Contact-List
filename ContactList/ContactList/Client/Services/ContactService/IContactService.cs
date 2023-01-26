namespace ContactList.Client.Services.ContactService
{
    public interface IContactService
    {
        List<Contact> Contacts { get; set; }
        Task GetContacts();
        Task<Contact> GetContact(int id);
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task RemoveContact(int id);
    }
}
