<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('pet_statuses', function (Blueprint $table) {
            $table->integer('id');

            $table->enum('status', [
                "idle", "hunt", "play", "cure", "eat", "sleep"
            ]);
            $table->time('duration')->nullable();

            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('pet_statuses');
    }
};
