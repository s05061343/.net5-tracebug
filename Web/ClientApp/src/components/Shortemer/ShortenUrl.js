import { store } from 'react-notifications-component';
import { apiShortenUrl } from '../../utils/api.js';

export const actionCreators = {
    post: () => (dispatch, getState) => {
        const appState = getState();

        dispatch({
            type: "POST",
            value: {
                isActive: true
            }
        });

        const json = { url: appState.shortemer.value.originalUrl }

        apiShortenUrl(json)
            .then(res => {
                console.log(res);
                const data = JSON.parse(res.request.response);
                console.log(data);
                dispatch({
                    type: "POST",
                    value: {
                        originalUrl: '',
                        translationUrl: '',
                        isActive: true
                    }
                });
                if (res.status === 200) {
                    store.addNotification({
                        title: "縮網址完成",
                        message: "連結以產生，感謝使用! " + data.data,
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
                        type: "POST",
                        value: {
                            originalUrl: appState.shortemer.value.originalUrl,
                            translationUrl: data.data,
                            isActive: false
                        }
                    });
                }
            })
            .catch(err => {
                dispatch({
                    type: "POST",
                    value: {
                        isActive: false
                    }
                });
                store.addNotification({
                    title: "縮網址產生失敗",
                    message: "縮網址產生失敗，請再試一次，如重複發生，請聯絡管理員。",
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

    setUrl: (originalUrl) => (dispatch, getState) => {
        const appState = getState();
        dispatch({
            type: "SET_URL",
            value: {
                originalUrl: originalUrl,
                translationUrl: '',
                isActive: false
            }
        });
    },
};

export const reducer = (shortemer, incomingAction) => {
    if (shortemer === undefined) {
        return {
            value: {
                originalUrl: '',
                translationUrl: '',
                isActive: false
            }
        };
    }

    switch (incomingAction.type) {
        case 'POST':
        case 'SET_URL':
            return {
                value: incomingAction.value
            };
        default:
            return shortemer;
    }
};

