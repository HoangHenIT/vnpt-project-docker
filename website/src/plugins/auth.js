import token from "./token";
var AuthPlugin = {
  data: {
    CLIENT_KEY: "WebClient-Token",
  },
  authenticate: function (stringToken) {
    this.setToken(stringToken);
  },
  
  isAuthenticated: function(){
    return token.getTokenFromStorage() != null;
  },
  destroy: function () {
    token.destroy();
    localStorage.clear();
  },
  ExpiresToken: function() {
      const now = Date.now(); 
      const getNow = formatYYYYMMDDHHMMSS(now);
      const expires = token.getTokenExpired(); // giả sử trả về timestamp (ms) hoặc null
      // Nếu không có expires → token chưa bao giờ được set hoặc đã bị xóa
      if (!expires) {
          return false;
      }
      // So sánh trực tiếp bằng timestamp (chuẩn và không lỗi múi giờ, định dạng)
      if (getNow >= expires) {
          // Token đã hết hạn → xóa
          token.destroy();
          localStorage.clear();
          return true; // true = đã hết hạn và đã được xử lý
      }
      return false; // vẫn còn hạn
  },
  setToken: function (stringToken) {
    token.setToken(stringToken);
  },
  getToken: function () {
    return token.getToken();
  },
  getClaims: function () {
    return token.getClaims();
  },
  getEmployerToken: function(){
    return token.getEmployerToken();
  },
  getEmployerId: function(){
    return token.getEmployerId();
  },
  
  saveClientInfoToStorage: function (clientInfo) {
    try {
      localStorage.removeItem(this.data.CLIENT_KEY);
      localStorage.setItem(this.data.CLIENT_KEY, JSON.stringify(clientInfo));
      return true;
    } catch (error) {
      return false;
    }
  },
  getClientInfoFromStorage: function () {
    if (localStorage.hasOwnProperty(this.data.CLIENT_KEY))
      return JSON.parse(localStorage.getItem(this.data.CLIENT_KEY));
    else return null;
  },
  getClientInfoProperty: function (name) {
    var obj = this.getClientInfoFromStorage();
    if (obj !== null) {
      return obj[name];
    } else {
      return null;
    }
  },
  formatYYYYMMDDHHMMSS(timestamp = Date.now()) {
    const date = new Date(timestamp);
    const pad = (n) => String(n).padStart(2, '0');
    
    return (
      date.getFullYear() +
      pad(date.getMonth() + 1) +
      pad(date.getDate()) +
      pad(date.getHours()) +
      pad(date.getMinutes()) +
      pad(date.getSeconds())
    );
  }
};

export default function (Vue) {
  Vue.auth = AuthPlugin;
  Object.defineProperties(Vue.prototype, {
    $auth: {
      get: function () {
        return Vue.auth;
      }
    }
  });
}

