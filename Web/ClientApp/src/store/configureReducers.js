import * as actions from '../actions/task_actions.js';
// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    loginUser: actions.reducer_loginUser,
    taskform_add: actions.reducer_taskform_add,
    taskform_query: actions.reducer_taskform_query,
    common: actions.reducer_common,
    newUser: actions.reducer_newUser
};