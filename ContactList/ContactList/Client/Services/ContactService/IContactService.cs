namespace ContactList.Client.Services.ContactService
{
    public interface IContactService
    {
        List<Contact> Contacts { get; set; }
        List<Category> Category { get; set; }
        Task GetContacts();
        Task GetCategories();
        Task<Contact> GetContact(int id);
        Task AddContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task RemoveContact(int id);
    }
}
