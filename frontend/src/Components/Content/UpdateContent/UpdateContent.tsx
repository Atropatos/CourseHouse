import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { deleteContent, getContent, updateContent } from '../../../Services/contentService';
import { Content } from '../../../Models/Content/Content';
import { ContentType } from '../../../Models/Content/ContentType';

const UpdateContent: React.FC = () => {
  const { contentId } = useParams<{ contentId: string }>();
  const [content, setContent] = useState<Content | null>(null);
  const [contentTitle, setContentTitle] = useState('');
  const [contentBody, setContentBody] = useState('');
  const [contentUrl, setContentUrl] = useState('');
  const [contentType, setContentType] = useState(ContentType.Text);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchContent = async () => {
      if (contentId) {
        const fetchedContent = await getContent(Number(contentId));
        setContent(fetchedContent);
        setContentTitle(fetchedContent.title);
        setContentBody(fetchedContent.text);
        setContentUrl(fetchedContent.contentUrl);
        setContentType(fetchedContent.contentType);
      }
    };
    fetchContent();
  }, [contentId]);

  const handleUpdateContent = async () => {
    if (content) {
      const updatedContent: Content = {
        ...content,
        title: contentTitle,
        text: contentBody,
        contentUrl: contentUrl,
        contentType: contentType,
      };

      try {
        await updateContent(updatedContent);
        navigate(-1); // Navigate back to the previous page
      } catch (error) {
        console.log(error);
      }
    }
  };

  const handleDeleteContent = async () => {
    try {
      const contentIdToDelete = Number(contentId);
      await deleteContent(contentIdToDelete);
      navigate(-1);
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-2xl font-bold mb-4">Edytuj zawartość</h1>
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">
          Tytuł:
          <input
            type="text"
            value={contentTitle}
            onChange={(e) => setContentTitle(e.target.value)}
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </label>
      </div>
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">
          Treść:
          <textarea
            value={contentBody}
            onChange={(e) => setContentBody(e.target.value)}
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </label>
      </div>
      <div className="mb-4">
        {/* <label className="block text-gray-700 text-sm font-bold mb-2">
          URL:
          <input
            type="text"
            value={contentUrl}
            onChange={(e) => setContentUrl(e.target.value)}
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </label> */}
      </div>
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2">
          Kategoria:
          <select
            value={contentType}
            onChange={(e) => setContentType(Number(e.target.value))}
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          >
            <option value={ContentType.Text}>Tekst</option>
            <option value={ContentType.Picture}>Obraz</option>
            <option value={ContentType.Video}>Video</option>
            <option value={ContentType.TestAnswer}>Test</option>
          </select>
        </label>
      </div>
      <div className="flex space-x-4">
        <button
          onClick={handleUpdateContent}
          className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
        >
          Zatwierdź
        </button>
        <button
          onClick={handleDeleteContent}
          className="bg-red-500 hover:bg-red-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
        >
          Usuń zawartość
        </button>
      </div>
    </div>
  );
};

export default UpdateContent;
