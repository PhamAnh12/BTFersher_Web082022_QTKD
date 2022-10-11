import EmployeeList from '../view/employee/EmployeeList.vue'
import Overview from '../view/pageOther/Overview.vue'
import Deposits from '../view/pageOther/Deposits.vue'
import Purchase from '../view/pageOther/Purchase.vue'
import Sale from '../view/pageOther/Sale.vue'
import Management from '../view/pageOther/Management.vue'
import Warehouse from '../view/pageOther/Warehouse.vue'
import Tool from '../view/pageOther/Tool.vue'
import Fixed_assets from '../view/pageOther/FixedAssets.vue'
import Tax from '../view/pageOther/Tax.vue'
import Pice from '../view/pageOther/Pice.vue'
import Synthetic from '../view/pageOther/Synthetic.vue'
import Budget from '../view/pageOther/Budget.vue'
import Report from '../view/pageOther/Report.vue'
import Financial_analysis from '../view/pageOther/FinancialAnalysis.vue'


import {createRouter,createWebHistory} from "vue-router"
// Định nghĩa router:
const routers = [
    {path:"/",component: Overview },
    {path:"/employees",component: EmployeeList},
    {path:"/deposits",component: Deposits },
    {path:"/purchase",component:  Purchase },
    {path:"/sale",component: Sale },
    {path:"/management",component: Management },
    {path:"/warehouse",component: Warehouse },
    {path:"/tool",component: Tool },
    {path:"/fixed-assets",component: Fixed_assets },
    {path:"/tax",component: Tax },
    {path:"/pice",component: Pice },
    {path:"/synthetic",component: Synthetic },
    {path:"/budget",component: Budget},
    {path:"/report",component: Report },
    {path:"/financial-analysis",component: Financial_analysis },
    
]
// Khỏi tạo router 
 const router = createRouter({
    history: createWebHistory(),
    routes: routers,
    linkActiveClass: 'active-link',
    linkExactActiveClass: 'exact-active-link',
 })
 export default router
 