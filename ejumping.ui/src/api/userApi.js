import globalUrl from "../components/constant/constant";

import axios from 'axios';

export function registerUser(model) {
        const url = globalUrl.root + '/api/auth/register'
        return axios.post(url, model, {
                headers: { Pragma: 'no-cache' },
                // withCredentials: true,
                responseType: 'json'
        });
}