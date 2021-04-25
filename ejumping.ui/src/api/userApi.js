import config from '../config';
import axios from 'axios';

export function registerUser(model) {
        const url = config.root + '/api/auth/register'
        return axios.post(url, model, {
                headers: { Pragma: 'no-cache' },
                // withCredentials: true,
                responseType: 'json'
        });
}
const requestInstance = axios.create({
        baseURL: config.root
});

export function request(url, options) {
        const requestOptions = Object.assign({}, options);
        requestOptions.url = url;

        return requestInstance.request(url, requestOptions)
                .then((response) => response)
                .catch((error) => error.response);
}
export function getLoggedInUser() {
        const url = config.root + '/api/user/';
        return axios.get(url, {
                headers: { Pragma: 'no-cache' },
                responseType: 'json'
        })
                .then((response) => response)
                .catch((error) => error.response);
}