import axios from 'axios';

// User相關的 api
const userRequest = axios.create({
    baseURL: '/',
});

// User 相關的 api
export const apiUserLogin = data => userRequest.post('/auth/v1/login', data);
export const apiAddTaskForm = data => userRequest.post('/task/v1/Insert', data, { withCredentials: true });
export const apiQueryTaskForm = data => userRequest.post('/task/v1/Query', data, { withCredentials: true });
export const apiDeleteTaskForm = data => userRequest.post('/task/v1/Delete', data, { withCredentials: true });
export const apiChangePrgressTaskForm = data => userRequest.post('/task/v1/ChangeProgress', data, { withCredentials: true });
export const apiChangePriorityTaskForm = data => userRequest.post('/task/v1/ChangePriority', data, { withCredentials: true });
export const apiCommon = data => userRequest.post('/task/v1/Commen', data, { withCredentials: true });
export const apiAddUser = data => userRequest.post('/task/v1/AddUser', data, { withCredentials: true });
