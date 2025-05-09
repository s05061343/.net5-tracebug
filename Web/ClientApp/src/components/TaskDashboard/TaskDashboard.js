﻿export const actionCreators = {
    logout: () => (dispatch, getState) => {
        sessionStorage.removeItem('authToken');
        dispatch({
            type: "USER_LOGOUT",
            user: {
                authToken: '',
                userId: '',
                password: '',
                isAuth: false
            }
        });
    },

    addForm: () => (dispatch, getState) => {
        sessionStorage.removeItem('authToken');
        dispatch({
            type: "USER_LOGOUT",
            user: {
                authToken: '',
                userId: '',
                password: '',
                isAuth: false
            }
        });
    }
};

export const reducer = (taskform, incomingAction) => {
    if (taskform === undefined) {
        return {
            user: {
                authToken: '',
                userId: '',
                password: '',
                isAuth: false
            }
        };
    }

    const action = incomingAction;
    console.log(action);

    switch (action.type) {
        case 'USER_LOGOUT':
            return {
                user: action.user
            };
        default:
            return taskform;
    }
};

