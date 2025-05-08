import React, { useState } from "react";

const Todoinput = ({ addTodo }) => {
  const [task, setTask] = useState("");

  const handleInputChange = (e) => {
    setTask(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (task.trim()) {
      addTodo(task);
      setTask("");  
    }
  };

  return (
    <form onSubmit={handleSubmit} className="m-5">
      <div className="form-group w-50">
      <input
        type="text"
        className="form-control"
        value={task}
        onChange={handleInputChange}
        placeholder="Add a new task"
      />
      <button type="submit" className="btn btn-primary mt-3">Add Task</button>
    </div> 
    </form>
  );
};

export default Todoinput;
