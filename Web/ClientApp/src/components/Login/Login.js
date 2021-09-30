import { store } from 'react-notifications-component';
import { apiUserLogin, apiAddTaskForm, apiQueryTaskForm, apiDeleteTaskForm, apiChangePrgressTaskForm, apiCommon, apiChangePriorityTaskForm } from '../../utils/api.js';

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
                            name: data.name,
                            role: data.role,
                            roleNo: data.roleNo,
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
                name: appState.loginUser.user.name,
                role: appState.loginUser.user.role,
                roleNo: appState.loginUser.user.roleNo,
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
                name: appState.loginUser.user.name,
                role: appState.loginUser.user.role,
                roleNo: appState.loginUser.user.roleNo,
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
                name: '',
                role: '',
                roleNo: '',
                isAuth: false
            }
        });
    },

    addformTitle: (title) => (dispatch, getState) => {
        const appState = getState();
        dispatch({
            type: "ADD_FORM_TITLE",
            form: {
                name: title,
                belongToLoginUser: appState.taskform_add.form.belongToLoginUser,
                description: appState.taskform_add.form.description,
                type: appState.taskform_add.form.type,
                priority: appState.taskform_add.form.priority
            }
        });
    },
    addformUser: (user) => (dispatch, getState) => {
        const appState = getState();
        console.log(user);
        dispatch({
            type: "ADD_FORM_USER",
            form: {
                name: appState.taskform_add.form.name,
                belongToLoginUser: user,
                description: appState.taskform_add.form.description,
                type: appState.taskform_add.form.type,
                priority: appState.taskform_add.form.priority
            }
        });
    },
    addformDescription: (description) => (dispatch, getState) => {
        const appState = getState();
        dispatch({
            type: "ADD_FORM_DESCRIPTION",
            form: {
                name: appState.taskform_add.form.name,
                belongToLoginUser: appState.taskform_add.form.belongToLoginUser,
                description: description,
                type: appState.taskform_add.form.type,
                priority: appState.taskform_add.form.priority
            }
        });
    },
    addformType: (type) => (dispatch, getState) => {
        const appState = getState();
        dispatch({
            type: "ADD_FORM_TYPE",
            form: {
                name: appState.taskform_add.form.name,
                belongToLoginUser: appState.taskform_add.form.belongToLoginUser,
                description: appState.taskform_add.form.description,
                type: type,
                priority: appState.taskform_add.form.priority
            }
        });
    },
    addformPriority: (priority) => (dispatch, getState) => {
        const appState = getState();
        dispatch({
            type: "ADD_FORM_PRIOROTY",
            form: {
                name: appState.taskform_add.form.name,
                belongToLoginUser: appState.taskform_add.form.belongToLoginUser,
                description: appState.taskform_add.form.description,
                type: appState.taskform_add.form.type,
                priority: priority
            }
        });
    },

    postFormAdd: () => (dispatch, getState) => {
        const appState = getState();
        const json = {
            name: appState.taskform_add.form.name,
            belongToLoginUser: appState.taskform_add.form.belongToLoginUser,
            description: appState.taskform_add.form.description,
            userId: appState.loginUser.user.userId,
            type: appState.taskform_add.form.type,
            priority: appState.taskform_add.form.priority,
        };
        console.log(json)
        apiAddTaskForm(json)
            .then(res => {
                console.log(res);
                if (res.status === 200) {
                    apiQueryTaskForm({ userId: appState.loginUser.user.userId })
                        .then(res => {
                            if (res.status === 200) {
                                dispatch({
                                    type: "QUERY_FORM",
                                    formdata: {
                                        belong: JSON.parse(res.request.response).data.belong,
                                        asign: JSON.parse(res.request.response).data.asign
                                    }
                                });
                            }
                        })
                        .catch(err => { console.log(err); return; });
                    store.addNotification({
                        message: "新增成功",
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
                }
            })
            .catch(err => {
                console.log(err);
                store.addNotification({
                    message: "新增失敗",
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
                return;
            });
    },
    postFormQuery: () => (dispatch, getState) => {
        const appState = getState();
        const json = { userId: appState.loginUser.user.userId };
        console.log(json)
        apiQueryTaskForm(json)
            .then(res => {
                if (res.status === 200) {
                    dispatch({
                        type: "QUERY_FORM",
                        formdata: {
                            belong: JSON.parse(res.request.response).data.belong,
                            asign: JSON.parse(res.request.response).data.asign
                        }
                    });
                }
            })
            .catch(err => { console.log(err); return; });
    },
    postFormDelete: (id) => (dispatch, getState) => {
        const appState = getState();
        const json = { id: id };
        console.log(json)
        apiDeleteTaskForm(json)
            .then(res => {
                console.log(res);
                apiQueryTaskForm({ userId: appState.loginUser.user.userId })
                    .then(res => {
                        if (res.status === 200) {
                            dispatch({
                                type: "QUERY_FORM",
                                formdata: {
                                    belong: JSON.parse(res.request.response).data.belong,
                                    asign: JSON.parse(res.request.response).data.asign
                                }
                            });
                        }
                    })
                    .catch(err => { console.log(err); return; });
            })
            .catch(err => { console.log(err); return; });
    },

    postFormChangeProgress: (id, progressNo) => (dispatch, getState) => {
        const appState = getState();
        const json = { id: id, progressNo: progressNo };
        console.log(json)
        apiChangePrgressTaskForm(json)
            .then(res => {
                console.log(res);
                apiQueryTaskForm({ userId: appState.loginUser.user.userId })
                    .then(res => {
                        if (res.status === 200) {
                            dispatch({
                                type: "QUERY_FORM",
                                formdata: {
                                    belong: JSON.parse(res.request.response).data.belong,
                                    asign: JSON.parse(res.request.response).data.asign
                                }
                            });
                        }
                    })
                    .catch(err => { console.log(err); return; });
            })
            .catch(err => { console.log(err); return; });
    },

    postCommon: () => (dispatch, getState) => {
        const appState = getState();
        apiCommon({})
            .then(res => {
                console.log(res);
                if (res.status === 200) {
                    dispatch({
                        type: "COMMON",
                        users: JSON.parse(res.request.response).data.users,
                        progress: JSON.parse(res.request.response).data.progress,
                        roles: JSON.parse(res.request.response).data.roles,
                        prioritys: JSON.parse(res.request.response).data.prioritys
                    });
                }
            });
    },

    postFormChangePriority: (id, priorityNo) => (dispatch, getState) => {
        const appState = getState();
        const json = { id: id, priorityNo: priorityNo };
        console.log(json)
        apiChangePriorityTaskForm(json)
            .then(res => {
                console.log(res);
                apiQueryTaskForm({ userId: appState.loginUser.user.userId })
                    .then(res => {
                        if (res.status === 200) {
                            dispatch({
                                type: "QUERY_FORM",
                                formdata: {
                                    belong: JSON.parse(res.request.response).data.belong,
                                    asign: JSON.parse(res.request.response).data.asign
                                }
                            });
                        }
                    })
                    .catch(err => { console.log(err); return; });
            })
            .catch(err => { console.log(err); return; });
    },

};

export const reducer_loginUser = (loginUser, incomingAction) => {
    if (loginUser === undefined) {
        return {
            user: {
                authToken: '',
                userId: '',
                password: '',
                name: '',
                role: '',
                roleNo: '',
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
export const reducer_taskform_add = (taskform_add, incomingAction) => {
    if (taskform_add === undefined) {
        return {
            form: {
                name: '',
                belongToLoginUser: '',
                description: '',
            }
        };
    }

    switch (incomingAction.type) {
        case 'ADD_FORM':
        case 'ADD_FORM_TITLE':
        case 'ADD_FORM_USER':
        case 'ADD_FORM_DESCRIPTION':
        case 'ADD_FORM_TYPE':
        case 'ADD_FORM_PRIOROTY':
            return {
                form: incomingAction.form
            };
        default:
            return taskform_add;
    }
};
export const reducer_taskform_query = (taskform_query, incomingAction) => {
    if (taskform_query === undefined) {
        return {
            formdata: {
                belong: [],
                asign: []
            }
        };
    }

    switch (incomingAction.type) {
        case 'QUERY_FORM':
            return {
                formdata: incomingAction.formdata
            };
        default:
            return taskform_query;
    }
};
export const reducer_common = (common, incomingAction) => {
    if (common === undefined) {
        return {
            users: [],
            progress: [],
            roles: [],
            prioritys: []
        };
    }

    switch (incomingAction.type) {
        case 'COMMON':
            return {
                users: incomingAction.users,
                progress: incomingAction.progress,
                roles: incomingAction.roles,
                prioritys: incomingAction.prioritys
            };
        default:
            return common;
    }
};
