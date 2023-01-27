using System.Net.Http.Json;

namespace ContactList.Client.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _http;
        public ContactService(HttpClient http)
        {
            _http = http;
        }
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<Category> Category { get; set; } = new List<Category>();

        public async Task AddContact(Contact contact)
        {
            //var result = 
                await _http.PostAsJsonAsync("api/Contact", contact);
            //var response = await result.Content.ReadFromJsonAsync<List<Contact>>();
            //Contacts = response;
        }

        public async Task<Contact> GetContact(int id)
        {
            var result = await _http.GetFromJsonAsync<Contact>($"api/Contact/{id}");
            if (result != null)
                return result;
            throw new Exception("Contact not found.");
        }

        public async Task GetContacts()
        {
            var result = await _http.GetFromJsonAsync<List<Contact>>("api/Contact");
            if (result != null)
                Contacts = result;
        }

        public async Task UpdateContact(Contact contact)
        {
            //var result =
            await _http.PutAsJsonAsync($"api/Contact/{contact.Id}", contact);
            //await SetContacts(result);
        }

        public async Task RemoveContact(int id)
        {
            //var result = 
                await _http.DeleteAsync($"api/Contact/{id}");
            //await SetContacts(result);
        }

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("api/Contact/categories");
            if (result != null)
                Category = result;
        }
    }
}
