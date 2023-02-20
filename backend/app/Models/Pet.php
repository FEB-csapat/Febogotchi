<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;
use Illuminate\Support\Carbon;

class Pet extends Model
{
    use HasFactory;

    protected $table = 'pets';
    protected $primaryKey = 'id';

    protected $now;

    protected $casts = [
        'is_alive' => 'boolean',
    ];
    protected $fillable = [
        'name', 'pet_type_id', 'user_id'
    ];

    protected $attributes = array(
        'age' => 0,
        'happiness' => 5,
        'wellbeing' => 5,
        'fittness' => 5,
        'sate' => 5,
        'energy' => 5,
        'is_alive' => true
    );
    
    public function __construct()
    {
        $this->attributes['birth_date'] =  Carbon::now();
    }

    public function user()
    {
        return $this->belongsTo(User::class, /*"user_id",*/ "pet_id");
    }

    public function petType()
    {
        return $this->hasOne(PetType::class, "pet_id");
    }

    public function updateModel($daysPassed){
        $minus = $daysPassed;

        $this->addHappiness(-$minus);
        $this->addWellbeing(-$minus);
        $this->addFittness(-$minus);
        $this->addSate(-$minus);
        $this->addEnergy(-$minus);

        $this->age += $daysPassed;

        if($this->happines <= 0 
        || $this->wellbeing <= 0 
        || $this->fittness <= 0 
        || $this->sate <= 0 
        || $this->energy <= 0)
        {
            $this->is_alive = false;
        }

        $this->save();
    }

    #region add methods 
    public function addHappiness($value){
        if($this->happiness + $value > 5){
            $this->happiness = 5;
            return;
        }if($this->happiness + $value < 0){
            $this->happiness = 0;
            return;
        }
        $this->happiness += $value;
    }
    public function addWellbeing($value){
        if($this->wellbeing + $value > 5){
            $this->wellbeing = 5;
            return;
        }if($this->wellbeing + $value < 0){
            $this->wellbeing = 0;
            return;
        }
        $this->wellbeing += $value;
    }
    public function addFittness($value){
        if($this->fittness + $value > 5){
            $this->fittness = 5;
            return;
        }if($this->fittness + $value < 0){
            $this->fittness = 0;
            return;
        }
        $this->fittness += $value;
    }
    public function addSate($value){
        if($this->sate + $value > 5){
            $this->sate = 5;
            return;
        }if($this->sate + $value < 0){
            $this->sate = 0;
            return;
        }
        $this->sate += $value;
    }
    public function addEnergy($value){
        if($this->energy + $value > 5){
            $this->energy = 5;
            return;
        }if($this->energy + $value < 0){
            $this->energy = 0;
            return;
        }
        $this->energy += $value;
    }
    #endregion

    #region action methods
    public function hunt()
    {
        $this->addHappiness(2);
        $this->addWellbeing(2);
        $this->addFittness(1);
        $this->addEnergy(-4);

        $this->save();
    }

    public function play()
    {
        $this->addHappiness(2);
        $this->addWellbeing(4);
        $this->addFittness(1);
        $this->addEnergy(-3);

        $this->save();
    }

    public function cure()
    {
        $this->addHappiness(-2);
        $this->addWellbeing(3);
        $this->addSate(-1);

        $this->save();
    }

    public function sleep()
    {
        $this->addWellbeing(2);
        $this->addEnergy(4);
        $this->addSate(-2);

        $this->save();
    }

    public function eat()
    {
        $this->addHappiness(1);
        $this->addWellbeing(1);
        $this->addSate(2);
        $this->addEnergy(1);

        $this->save();
    }
    #endregion
}
