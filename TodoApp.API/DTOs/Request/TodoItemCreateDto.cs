namespace TodoApp.API.DTOs.Request
{
    public class TodoItemRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}
//Jab client POST ya PUT kare to hum sirf title aur isCompleted lenge — Id nahi lenge, kyunki woh DB khud generate karta hai.