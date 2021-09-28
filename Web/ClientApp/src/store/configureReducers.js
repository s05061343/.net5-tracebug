import * as Login from '../components/Login/Login.js';
import * as MyTask from '../components/Login/MyTask.js';
// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    loginUser: Login.reducer,
    taskform: MyTask.reducer
};
