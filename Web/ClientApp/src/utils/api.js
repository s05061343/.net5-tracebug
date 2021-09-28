import axios from 'axios';

// User相關的 api
const userRequest = axios.create({
    baseURL: '/'
});

// User 相關的 api
export const apiUserLogin = data => userRequest.post('/auth/default/login', data);
export const apiUserLoginCheck = data => userRequest.post('/auth/default/CookieLogin', data);
export async function getApiUserLoginCheck() {
    try {
        const item = await apiUserLoginCheck({});
        return item;
    } catch (err) {
        console.error(err);
        sessionStorage.removeItem("authToken");
    }
}

const shortenRequest = axios.create({
    baseURL: 'https://tomz-shorten-url.herokuapp.com',
});
export const apiShortenUrl = data => shortenRequest.post('/urlshortemer/default/shorten', data);