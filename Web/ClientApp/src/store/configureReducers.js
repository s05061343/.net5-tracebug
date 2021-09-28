import * as Login from '../components/Login/Login.js';
import * as ShortenUrl from '../components/Shortemer/ShortenUrl.js';
// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    loginUser: Login.reducer,
    shortemer: ShortenUrl.reducer
};
