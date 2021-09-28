import { store } from 'react-notifications-component';
import { apiUserLogin } from '../../utils/api.js';

export const actionCreators = {
    post: () => (dispatch, getState) => {
        const appState = getState();

        const formData = new FormData();
        formData.append('userId', appState.loginUser.user.userId);
        formData.append('password', appState.loginUser.user.password);

        apiUserLogin(formData)
            .then(res => {
                console.log(res);
                const data = JSON.parse(res.request.response);
                console.log(data);
                if (res.status === 200) {
                    sessionStorage.setItem('authToken', JSON.stringify(data.authToken));
                    store.addNotification({
                        message: "登入成功",
                        type: "success",
                        insert: "top",
                        container: "top-right",
                        animationIn: ["animate__animated", "animate__fadeIn"],
                        animationOut: ["animate__animated", "animate__fadeOut"],
                        dismiss: {
                            duration: 5000,
                            onScreen: true
                        }
                    });
                    dispatch({
                        type: "POST_LOGIN",
                        user: {
                            authToken: data.authToken,
                            userId: data.userId,
                            password: '',
                            isAuth: data.authToken ? true : false
                        },
                    });
                }
            })
            .catch(err => {
                console.log(err);
                store.addNotification({
                    title: "登入失敗",
                    message: "帳號或密碼輸入錯誤，請重新確認後重試",
                    type: "warning",
                    insert: "top",
                    container: "top-right",
                    animationIn: ["animate__animated", "animate__fadeIn"],
                    animationOut: ["animate__animated", "animate__fadeOut"],
                    dismiss: {
                        duration: 5000,
                        onScreen: true
                    }
                });
                //    dispatch({
                //        type: "ERROR_MESSAGE",
                //        user: {
                //            authToken: '',
                //            userId: appState.loginUser.user.userId,
                //            password: appState.loginUser.user.password,
                //            isAuth: false
                //        },
                //    });
            });
    },

    setUserId: (userId) => (dispatch, getState) => {
        const appState = getState();
        dispatch({
            type: "SET_USERID",
            user: {
                authToken: '',
                userId: userId,
                password: appState.loginUser.user.password,
                isAuth: false
            }
        });
    },

    setPassword: (password) => (dispatch, getState) => {
        const appState = getState();
        dispatch({
            type: "SET_PASSWORD",
            user: {
                authToken: '',
                userId: appState.loginUser.user.userId,
                password: password,
                isAuth: false
            }
        });
    },

    logout: () => (dispatch, getState) => {
        sessionStorage.removeItem('authToken');
        document.cookie = "AuthToken=; path=/;";
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

export const reducer = (loginUser, incomingAction) => {
    if (loginUser === undefined) {
        return {
            user: {
                authToken: '',
                userId: '',
                password: '',
                isAuth: false
            }
        };
    }

    switch (incomingAction.type) {
        case 'POST_LOGIN':
        case 'SET_USERID':
        case 'SET_PASSWORD':
        case 'USER_LOGOUT':
        case 'ERROR_MESSAGE':
            return {
                user: incomingAction.user
            };
        default:
            return loginUser;
    }
};

