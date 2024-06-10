import React from "react";

type Props = {};

const ErrorPage = (props: Props) => {
  return (
    <div className="flex justify-center h-400">
      <div className="bg-gray-200 rounded-lg shadow-lg p-6">
        <h1 className="text-2xl font-bold text-gray-800">Error Page</h1>
        <p className="text-gray-600 mt-2">Oops! Something went wrong.</p>
      </div>
    </div>
  );
};

export default ErrorPage;
