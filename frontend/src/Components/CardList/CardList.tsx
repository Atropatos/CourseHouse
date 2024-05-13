import React from 'react'
import Card from '../Card/Card';

interface Props  {}

const CardList: React.FC<Props> = (props: Props): JSX.Element => {
  return <div>
    <Card companyName='Apple' ticker='AAPL' price={100}/>
    <Card companyName='MSF' ticker='MSF' price={222}/>
    <Card companyName='ASD' ticker='DDS' price={1241}/>
    
  </div>
};

export default CardList