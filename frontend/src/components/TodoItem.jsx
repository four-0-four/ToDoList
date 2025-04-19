// src/components/TodoItem.jsx
import React from 'react';

const TodoItem = ({ todo, handleDelete, handleUpdate }) => (
  <li style={{ marginTop: '1rem' }}>
    <strong>{todo.task}</strong>: {todo.description}
    <div>
      <button onClick={() => handleDelete(todo.id)}>Delete</button>
      <button onClick={() => handleUpdate(todo.id)}>Update</button>
    </div>
  </li>
);

export default TodoItem;
