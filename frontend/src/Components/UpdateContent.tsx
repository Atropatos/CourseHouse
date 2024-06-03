// src/components/UpdateContent.tsx
import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { deleteContent, getContent, updateContent } from '../Services/contentService';
import { Content } from '../Models/Content/Content';
import { ContentType } from '../Models/Content/ContentType';

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

  const handleDeleteContent = async() => {
    try {
      var contentIdToDelete = Number(contentId);
      await deleteContent(contentIdToDelete);
      navigate(-1);
    }
    catch (error) {
      console.log(error);
    }
  }

  return (
    <div>
      <h1>Edytuj zawartość</h1>
      <div>
        <label>
          Tytuł:
          <input
            type="text"
            value={contentTitle}
            onChange={(e) => setContentTitle(e.target.value)}
          />
        </label>
      </div>
      <div>
        <label>
          Treść:
          <textarea
            value={contentBody}
            onChange={(e) => setContentBody(e.target.value)}
          />
        </label>
      </div>
      <div>
        {/* <label>
          URL:
          <input
            type="text"
            value={contentUrl}
            onChange={(e) => setContentUrl(e.target.value)}
          />
        </label> */}
      </div>
      <div>
        <label>
          Kategoria:
          <select
            value={contentType}
            onChange={(e) => setContentType(Number(e.target.value))}
          >
            <option value={ContentType.Text}>Tekst</option>
            <option value={ContentType.Picture}>Obraz</option>
            <option value={ContentType.Video}>Video</option>
            <option value={ContentType.TestAnswer}>Test</option>
          </select>
        </label>
      </div>
      <button onClick={handleUpdateContent}>Zatwierdź</button>
      <button onClick={handleDeleteContent}>Usuń zawartość</button>
    </div>
  );
};

export default UpdateContent;
