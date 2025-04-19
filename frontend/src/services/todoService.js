// src/services/todoService.js
import axios from 'axios';

const API_URL = 'http://localhost:5297/api/ToDo';

export const getAllToDos = () => axios.get(API_URL);
export const getToDoById = (id) => axios.get(`${API_URL}/${id}`);
export const addToDo = (todo) => axios.post(API_URL, todo);
export const updateToDo = (id, todo) => axios.put(`${API_URL}/${id}`, todo);
export const deleteToDo = (id) => axios.delete(`${API_URL}/${id}`);
