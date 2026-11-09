import path from "path";

const rootPath = "";


export const Routings = {
    home: {
        toNavigate: () => `${rootPath}/`,
    },
    good: {
        list: {
            path: 'goods',
            toNavigate: () => `${rootPath}/${Routings.good.list.path}`,
        },
        create: {
            path: 'goods/create',
            toNavigate: () => `${rootPath}/${Routings.good.create.path}`,
        },
        view: {
            path: "goods/view/:uid",
            toNavigate: (uid: string) =>
                `${rootPath}/${Routings.good.view.path.replace(':uid', uid)}`,
        },
        edit: {
            path: "goods/edit/:uid",
            toNavigate: (uid: string) =>
                `${rootPath}/${Routings.good.edit.path.replace(':uid', uid)}`,
        },
    },
    shop: {
        list: {
            path: 'shops',
            toNavigate: () => `${rootPath}/${Routings.shop.list.path}`,
        },
        create: {
            path: 'shops/create',
            toNavigate: () => `${rootPath}/${Routings.shop.create.path}`,
        },
        view: {
            path: "shops/view/:uid",
            toNavigate: (uid: string) =>
                `${rootPath}/${Routings.shop.view.path.replace(':uid', uid)}`,
        },
        edit: {
            path: "shops/edit/:uid",
            toNavigate: (uid: string) =>
                `${rootPath}/${Routings.shop.edit.path.replace(':uid', uid)}`,
        },
    },
    client: {
        list: {
            path: 'clients',
            toNavigate: () => `${rootPath}/${Routings.client.list.path}`,
        },
        create: {
            path: 'clients/create',
            toNavigate: () => `${rootPath}/${Routings.client.create.path}`,
        },
        view: {
            path: "clients/view/:uid",
            toNavigate: (uid: string) =>
                `${rootPath}/${Routings.client.view.path.replace(':uid', uid)}`,
        },
        edit: {
            path: "clients/edit/:uid",
            toNavigate: (uid: string) =>
                `${rootPath}/${Routings.client.edit.path.replace(':uid', uid)}`,
        },
    },
};