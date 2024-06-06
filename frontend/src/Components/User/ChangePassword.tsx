import React, { useState } from 'react';
import { changePassword } from '../../Services/userService';
const ChangePassword: React.FC = () => {
    const [currentPassword, setCurrentPassword] = useState('');
    const [newPassword, setNewPassword] = useState('');
    const [message, setMessage] = useState<string | null>(null);
    const [showPopup, setShowPopup] = useState(false);
  
    const handleSubmit = async (e: React.FormEvent) => {
      e.preventDefault();
      try {
        await changePassword(currentPassword, newPassword);
        setMessage('Hasło zostało zmienione');
        setShowPopup(true);
        setTimeout(() => setShowPopup(false), 3000); // Hide the popup after 3 seconds
      } catch (error:any) {
        setMessage(error.message);
        setShowPopup(true);
        setTimeout(() => setShowPopup(false), 3000); // Hide the popup after 3 seconds
      }
    };
  
    return (
      <div className="container mx-auto p-4 relative">
        <h1 className="text-2xl font-bold mb-4">Zmień hasło</h1>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="currentPassword" className="block text-gray-700 font-bold mb-2">Obecne hasło</label>
            <input
              type="password"
              id="currentPassword"
              value={currentPassword}
              onChange={(e) => setCurrentPassword(e.target.value)}
              className="block w-full p-2 border border-gray-300 rounded"
              required
            />
          </div>
          <div className="mb-4">
            <label htmlFor="newPassword" className="block text-gray-700 font-bold mb-2">Nowe hasło</label>
            <input
              type="password"
              id="newPassword"
              value={newPassword}
              onChange={(e) => setNewPassword(e.target.value)}
              className="block w-full p-2 border border-gray-300 rounded"
              required
            />
          </div>
          <button
            type="submit"
            className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600"
          >
            Zmień hasło
          </button>
        </form>
        {showPopup && (
          <div className="fixed inset-x-0 top-0 flex justify-center items-center">
            <div className="bg-green-500 text-white py-2 px-6 rounded-full shadow-lg mt-4">
              {message}
            </div>
          </div>
        )}
      </div>
    );
  };
  
  export default ChangePassword;