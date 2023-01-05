export default {
    getCookie(cname) {//get cookie from local
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
    },
    strToObj(str) {//convert string to object
      var obj = {};
      if (str && typeof str === "string") {
        var objStr = str.match(/\{(.)+\}/g);
        eval("obj =" + objStr);
      }
      return obj;
    },
    getToken(){
      var section_local= this.getCookie("web_token");
      if(section_local){
          var tok =this.strToObj(section_local);
          return tok.token;
          
      }else{
          return null
      }
    },
    getUsername(){
      var section_local= this.getCookie("web_token");
      if(section_local){
          var tok =this.strToObj(this.getCookie("web_token"));
          return tok.user.username;
          
      }else{
          return null
      }
    },
    getFullname(){
      var section_local= this.getCookie("vnpt_news_token");
      if(section_local){
          var tok =this.strToObj(this.getCookie("vnpt_news_token"));
          return tok.user.fullname;
          
      }else{
          return null
      }
    }
}