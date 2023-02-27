import LayoutMain from '@/layouts/MainLayout.vue'
import Profile from '../admin/profile/Profile.vue'


export default [
    {
      path: '/admin',
      name: 'Admin',
      component: LayoutMain,
      redirect: '/admin/home',
      children: [
        {
          path: 'home',
          name: 'Home',
          component: () => import('../../components/home/Home.vue'),
          meta: {
            title: 'Trang chủ'
          }
        },
        {
          path: 'profile',
          name: 'Profile',
          component: Profile,
          meta: {
            title: 'Người dùng'
          }
        },
      ]
    }
  ]