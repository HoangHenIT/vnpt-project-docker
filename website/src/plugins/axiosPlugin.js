import axios from "axios"

// default
const baseUrl = process.env.API;
const TOKEN_KEY = 'web_token'
axios.defaults.baseURL = baseUrl;
let token = document.head.querySelector('meta[name="csrf-token"]');
// axios.defaults.headers.common['X-CSRF-TOKEN'] = token.content;
axios.defaults.headers = {
  "Content-Type": "application/json",
  // "X-CSRF-TOKEN" : token.content
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
    var token = getCookie(TOKEN_KEY);
    if (token) {
      var access_token = strToObj(token);
      request.headers.Authorization = `Bearer ${access_token.token}`;
      
    }
    
    return request

});
function getCookie(cname) {//get cookie from local
  var name = cname + "=";
  let decodedCookie = decodeURIComponent(document.cookie).split(';')
  for (var i = 0; i < decodedCookie.length; i++) {
    let cookie = decodedCookie[i].trim();
    const index=cookie.indexOf(name)
    if(index>-1){
      return cookie.substring(name.length, cookie.length)
    }
  }
  return null
}
function strToObj(str) {//convert string to object
  var obj = {};
  if (str && typeof str === "string") {
    var objStr = str.match(/\{(.)+\}/g);
    eval("obj =" + objStr);
  }
  return obj;
}


// doing something with the response
axios.interceptors.response.use(
  response => {
    const now = Date.now();
    // console.info(
    //   `Api Call ${response.config.url} took ${now -
    //     response.config.config.start}ms`
    // );
    // all 2xx/3xx responses will end here
    return response;
  },
  error => {
    // all 4xx/5xx responses will end here
    //return Promise.reject(error);
    return Promise.reject(error);
  }
);

export default axios;
