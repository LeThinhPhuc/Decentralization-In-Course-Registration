import { useContext } from 'react';
import { AccountContext } from '../contexts/AccountContext';

const useAuthToken = () => {
  const { getToken } = useContext(AccountContext);
  return getToken;
};

export default useAuthToken;
