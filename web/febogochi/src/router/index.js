import { createRouter, createWebHistory } from 'vue-router'
import IndexView from "@/views/IndexView.vue";
import FeedView from "@/views/FeedView.vue";
import PlayView from "@/views/PlayView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      name:'Index',
      path:'/',
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
    
  ]
})

export default router
