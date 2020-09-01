import { NavigationRoutes as Routes } from './navigation-routes';

export class NavigationPaths {
  static login = `/${Routes.login.root}`;
  static order = `/${Routes.order.root}`;
  // static plan = {
  //   root: `/${Routes.plan.root}`,
  //   details: {
  //     root: `/${Routes.plan.root}/${Routes.plan.details.root}`,
  //     resources: `/${Routes.plan.root}/${Routes.plan.details.root}/${Routes.plan.details.resources}`,
  //     services: `/${Routes.plan.root}/${Routes.plan.details.root}/${Routes.plan.details.services}`,
  //     materials: `/${Routes.plan.root}/${Routes.plan.details.root}/${Routes.plan.details.materials}`,
  //   },
  // };
}
