const rootPath2 = "";


export const Routings = {
    home: {
        toNavigate: () => `${rootPath2}/`,
    },
    good: {
        list: {
            path: 'goods',
            toNavigate: () => `${rootPath2}/${Routings.good.list.path}`,
        },
    },
    shop: {
        list: {
            path: 'shops',
            toNavigate: () => `${rootPath2}/${Routings.shop.list.path}`,
        },
    },
    client: {
        list: {
            path: 'clients',
            toNavigate: () => `${rootPath2}/${Routings.client.list.path}`,
        },
    },
};