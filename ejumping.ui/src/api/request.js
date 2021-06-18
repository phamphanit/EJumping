import config from '../config';
import axios from 'axios';
import { call } from "@redux-saga/core/effects";

const requestInstance = axios.create({
        baseURL: config.root
});

export function request(url, options) {
        const requestOptions = Object.assign({}, options);
        requestOptions.url = url;

        return requestInstance.request(url, requestOptions)
                .then((response) => ({ payload: response.data, header: response.headers }))
                .catch((error) => ({ error }));
}


export default function* requestSaga(url, options = {}) {
        const { payload, error } = yield call(request, url, options);
        if (error) {
                throw error;
        }
        return payload;
}