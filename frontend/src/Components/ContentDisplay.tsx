// src/components/ContentDisplay.tsx
import React from 'react';
import { Content } from '../Models/Content/Content';
import { ContentType } from '../Models/Content/ContentType';

interface ContentDisplayProps {
  content: Content;
}

const ContentDisplay: React.FC<ContentDisplayProps> = ({ content }) => {
  switch (content.contentType) {
    case ContentType.Text:  
      return (
        <div>
          <h4>tytuł contentu: {content.title}</h4>
          <p>tekst contentu: {content.text}</p>
        </div>
      );
    case ContentType.Picture:
      return (
        <div>
          <h4>{content.title}</h4>
          <img src={content.contentUrl} alt={content.title} />
        </div>
      );
    case ContentType.Video:
      return (
        <div>
          <h4>{content.title}</h4>
          <video src={content.contentUrl} controls />
        </div>
      );
    case ContentType.TestAnswer:
      return (
        <div>
          <h4>{content.title}</h4>
          <p>{content.text}</p>
          <p>Correct: {content.correct ? 'Yes' : 'No'}</p>
        </div>
      );
    default:
      return null;
  }
};

export default ContentDisplay;
