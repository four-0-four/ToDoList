// src/App.jsx
import React, { useEffect, useState } from 'react';
import TodoForm from './components/TodoForm';
import TodoList from './components/TodoList';
import {
  getAllToDos,
  addToDo,
  deleteToDo,
  updateToDo,
  getToDoById,
} from './services/todoService';

function App() {
  const [todos, setTodos] = useState([]);
  const [isUpdating, setIsUpdating] = useState(false);
  const [newToDo, setNewToDo] = useState({id: -1,  task: '', description: '' });

  useEffect(() => {
    getAllToDos().then((res) => setTodos(res.data));
  }, []);

  const handleAdd = () => {
    const newItem = {
      id: Math.max(0, ...todos.map((t) => t.id)) + 1,
      task: newToDo.task,
      description: newToDo.description,
    };

    addToDo(newItem).then((res) => {
      setTodos([...todos, res.data]);
      setNewToDo({ task: '', description: '' });
    });
  };

  const handleDelete = (id) => {
    deleteToDo(id).then(() => {
      setTodos(todos.filter((todo) => todo.id !== id));
    });
  };

  const handleUpdate = (id) => {
    getToDoById(id).then((res)=>{
      setNewToDo({
        id: res.data.id,
        task: res.data.task,
        description: res.data.description
      });
      setIsUpdating(true);
    })
  }

  const handlePut = () => {
    const updated = {
      id: newToDo.id,
      task: newToDo.task,
      description: newToDo.description,
    };

    updateToDo(newToDo.id, updated).then(() => {
      setTodos(todos.map((todo) => (todo.id === newToDo.id ? updated : todo)));
      setNewToDo({ task: '', description: '' });
    });
  };

  return (
    <div style={{ padding: '2rem', fontFamily: 'Arial' }}>
      <h1>📝 ToDo List</h1>
      <TodoForm
        newToDo={newToDo}
        setNewToDo={setNewToDo}
        handleAdd={handleAdd}
        handlePut={handlePut}
        isUpdating={isUpdating}
      />
      <TodoList
        todos={todos}
        handleDelete={handleDelete}
        handleUpdate={handleUpdate}
      />
    </div>
  );
}

export default App;
