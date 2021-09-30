import * as Login from '../components/Login/Login.js';
// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    loginUser: Login.reducer_loginUser,
    taskform_add: Login.reducer_taskform_add,
    taskform_query: Login.reducer_taskform_query,
    common: Login.reducer_common
};
