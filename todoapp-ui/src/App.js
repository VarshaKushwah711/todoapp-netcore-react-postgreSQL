import React, { useState, useEffect } from "react";
import axios from "axios";
import InputForm from "./components/TodoInput";
import TodoList from "./components/TodoList";
import TodoHeader from "./components/TodoHeader";

const App = () => {
  const [todos, setTodos] = useState([]);
  const [loading, setLoading] = useState(true);

  const fetchTodos = async () => {
    try {
      const response = await axios.get("http://localhost:5026/api/TodoItems"); 
      setTodos(response.data);
      setLoading(false);
    } catch (error) {
      console.error("Error fetching todos:", error);
      setLoading(false);
    }
  };

  const addTodo = async (title) => {
    try {
      const response = await axios.post("http://localhost:5026/api/TodoItems", {
        title,
      });
      setTodos([...todos, response.data]); 
    } catch (error) {
      console.error("Error adding todo:", error);
    }
  };

  useEffect(() => {
    fetchTodos(); 
  }, []);

  return (
    <>
     <TodoHeader/>
    <div className="container">
      <InputForm addTodo={addTodo} />
      {loading ? <p>Loading...</p> : <TodoList todos={todos} />}
    </div>
    </>
  );
};

export default App;
