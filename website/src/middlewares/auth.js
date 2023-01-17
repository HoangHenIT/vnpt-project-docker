export default function auth ({ next, store }) {
    if (!this.$auth.isAuthenticated()) {
        debugger
      return next({
        name: 'login'
      })
    }
    return next()
  }
  