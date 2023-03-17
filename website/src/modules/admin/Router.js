import LayoutMain from '@/layouts/MainLayout.vue'
import Profile from '../admin/profile/Profile.vue'
import CategoryMenu from '../admin/categorymenu/CategoryMenu.vue'
import PermissionIndex from '../admin/permission/Permission.vue'


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
        {
          path: 'categorymenu',
          name: 'CategoryMenu',
          component: CategoryMenu,
          meta: {
            title: 'Danh mục menu'
          }
        },
        {
          path: 'permission',
          name: 'PermissionIndex',
          component: PermissionIndex,
          meta: {
            title: 'Phân quyền'
          }
        },
        
      ]
    }
  ]