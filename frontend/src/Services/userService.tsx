import axios from 'axios';

const api = 'http://localhost:5010/api/';

export const changePassword = async (currentPassword: string, newPassword: string) => {
  try {
    const response = await axios.post(`${api}user/change-password`, {
      currentPassword,
      newPassword
    });
    return response.data;
  } catch (error) {
    throw new Error( 'Error while changing password');
  }
};
