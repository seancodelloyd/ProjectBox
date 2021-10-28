const ENV = {
  dev: {
    apiUrl: 'http://localhost:44381',
    oAuthConfig: {
      issuer: 'http://localhost:44381',
      clientId: 'Autoboxd_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access Autoboxd',
    },
    localization: {
      defaultResourceName: 'Autoboxd',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44381',
    oAuthConfig: {
      issuer: 'http://localhost:44381',
      clientId: 'Autoboxd_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access Autoboxd',
    },
    localization: {
      defaultResourceName: 'Autoboxd',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
