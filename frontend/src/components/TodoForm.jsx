// src/components/TodoForm.jsx
import React from 'react';

const TodoForm = ({ newToDo, setNewToDo, handleAdd, handlePut, isUpdating }) => (
  <div className="space-x-2 mb-4">
    <input
      placeholder="Task"
      value={newToDo.task}
      onChange={(e) => setNewToDo({ ...newToDo, task: e.target.value })}
    />
    <input
      placeholder="Description"
      value={newToDo.description}
      onChange={(e) => setNewToDo({ ...newToDo, description: e.target.value })}
    />
    <button onClick={isUpdating?handlePut:handleAdd}>{isUpdating?"Update":"Add"}</button>
  </div>
);

export default TodoForm;
