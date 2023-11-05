const CryptoJS = require("crypto-js")
const passphrase = "Ho@ngHeN@97231#%";
export default {
    encrypt (src) {
        return CryptoJS.AES.encrypt(src, passphrase).toString()
    },
    
    decrypt (src) {
        const bytes = CryptoJS.AES.decrypt(src, passphrase)
        const originalText = bytes.toString(CryptoJS.enc.Utf8)
        return originalText
    }
}