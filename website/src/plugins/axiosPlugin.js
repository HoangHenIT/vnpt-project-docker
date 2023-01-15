import axios from "axios"

// default
const baseUrl = process.env.API;
const TOKEN_KEY = 'WebClient-Token'

axios.defaults.baseURL = baseUrl;
axios.defaults.headers = {
  "Content-Type": "application/json",
  // "Token-id": "97388db0-6ce9-11ea-bc55-0242ac130003",
  "Mac-address": "WEB"
};
// doing something with the request
axios.interceptors.request.use(
  (request) => {
    var config = {}
    if (request.config) {
        config = request.config
    }
    config.start = Date.now()
    request.config = config
    var token =  localStorage.getItem("WebClient-Token") ? localStorage.getItem("WebClient-Token") : null
   if (token) {
        let access_token = JSON.parse(localStorage.getItem(TOKEN_KEY))
        request.headers.Authorization = `Bearer ${access_token.data.token.access_token}`;
    }
  return request;
});

// doing something with the response
axios.interceptors.response.use(
  response => {
    const now = Date.now();
    console.info(
      `Api Call ${response.config.url} took ${now -
        response.config.config.start}ms`
    );
    // all 2xx/3xx responses will end here
    return response;
  },
  error => {
    // all 4xx/5xx responses will end here
    console.log(error);
    //return Promise.reject(error);
    return Promise.reject(error.response);
  }

);

export default axios;
