namespace TodoApp.API.DTOs.Response
{
    public class TodoItemResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
//Jab client GET karta hai, to hum usse Id bhi bhejte hain, kyunki woh identify karne ke kaam aata hai.