import React from "react";

const TodoList = ({ todos }) => {
  return (
    <div className="container m-4">
    <table className="table table-bordered table-striped table-hover ">
      <thead className="table-dark">
        <tr>
          <th>No.</th>
          <th>Task</th>
          <th>Status</th>
        </tr>
      </thead>
      <tbody>
        {todos.map((todo, index) => (
          <tr key={index}>
            <td>{index + 1 }</td>
            <td>{todo.title}</td>
            <td>{todo.isCompleted ? "Complete" : "Pending"}</td>
          </tr>
        ))}
      </tbody>
    </table>
    </div>
  );
};

export default TodoList;
