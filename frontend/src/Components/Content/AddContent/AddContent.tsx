import React, { useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { postContent } from '../../../Services/contentService';
import { ContentType } from '../../../Models/Content/ContentType';
import { Content } from '../../../Models/Content/Content';

const AddContent: React.FC = () => {
  const { viewId } = useParams<{ viewId: string }>();
  const [contentTitle, setContentTitle] = useState('');
  const [contentBody, setContentBody] = useState('');
  const [contentUrl, setContentUrl] = useState('');
  const [contentType, setContentType] = useState(ContentType.Text); // Default to Text
  const navigate = useNavigate();

  const handleAddContent = async () => {
    const courseViewId = Number(viewId);

    const content: Omit<Content, 'contentId'> = {
      order: 0, // Assign appropriate order if required
      courseViewId: courseViewId,
      title: contentTitle,
      text: contentBody,
      contentUrl: contentUrl,
      correct: false, // Provide appropriate value if required
      contentType: contentType, // Use enum value
    };

    try {
      const result = await postContent(content);
      console.log('Content added successfully', result);
      navigate(`/courseView/${viewId}`);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Dodawanie Contentu</h1>
      <div className="mb-4">
        <label className="block text-gray-700 font-bold mb-2">
          Tytuł:
          <input
            type="text"
            value={contentTitle}
            onChange={(e) => setContentTitle(e.target.value)}
            className="block w-full p-2 border border-gray-300 rounded"
          />
        </label>
      </div>
      <div className="mb-4">
        <label className="block text-gray-700 font-bold mb-2">
          Treść:
          <textarea
            value={contentBody}
            onChange={(e) => setContentBody(e.target.value)}
            className="block w-full p-2 border border-gray-300 rounded"
          />
        </label>
      </div>
      <div className="mb-4">
        <label className="block text-gray-700 font-bold mb-2">
          Typ Contentu:
          <select
            value={contentType}
            onChange={(e) => setContentType(Number(e.target.value))}
            className="block w-full p-2 border border-gray-300 rounded"
          >
            <option value={ContentType.Text}>Text</option>
            <option value={ContentType.Picture}>Obraz</option>
            <option value={ContentType.Video}>Video</option>
            <option value={ContentType.TestAnswer}>Test</option>
          </select>
        </label>
      </div>
      <button
        onClick={handleAddContent}
        className="bg-blue-500 text-white py-2 px-4 rounded hover:bg-blue-600"
      >
        Dodaj Content
      </button>
    </div>
  );
};

export default AddContent;
