<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;
use Illuminate\Queue\Connectors\NullConnector;

class PetStatusResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return array|\Illuminate\Contracts\Support\Arrayable|\JsonSerializable
     */
    public function toArray($request)
    {
      //  return $request;
      //  return parent::toArray($request);


        
        return [
            'id' => $this->id,
            'status' => $this->status,
            'duration' => $this->duration
                ? $this->duration->format('H:i:s')
                : null
        ];
        
    }
}
