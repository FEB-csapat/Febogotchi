<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class PetStatus extends Model
{
    use HasFactory;


    protected $table = 'pet_statuses';
    protected $primaryKey = 'id';


    protected $casts = [
        'duration' => 'datetime: H:i',
    ];
    protected $fillable = [
        'status', 'duration'
    ];
    
    public function pets()
    {
        return $this->hasMany(Pet::class, "pet_status_id");
    }

    

}
