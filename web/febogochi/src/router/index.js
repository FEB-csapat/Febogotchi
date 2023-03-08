import { createRouter, createWebHistory } from 'vue-router'
import IndexView from "@/views/IndexView.vue";
import FeedView from "@/views/FeedView.vue";
import PlayView from "@/views/PlayView.vue";
import RegisterView from "@/views/RegisterView.vue";
import LoginView from "@/views/LoginView.vue";
import CreateView from "@/views/CreateView.vue";
import StartView from "@/views/StartView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      name:'Index',
      path:'/index',
      component: IndexView
    },
    {
      name:'Feed',
      path:'/feed',
      component: FeedView
    },
    {
      name:'Play',
      path:'/play',
      component: PlayView
    }
    ,
    {
      name:'Register',
      path:'/register',
      component: RegisterView
    }
    ,
    {
      name:'Login',
      path:'/',
      component: LoginView
    }
    ,
    {
      name:'CreateView',
      path:'/create',
      component: CreateView
    }
  ]
})

export default router
